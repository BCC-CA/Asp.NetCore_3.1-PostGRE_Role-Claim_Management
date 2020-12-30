# Complete ASP.Net Core deploy in Centos 8

If you need to ***deploy the whole project in a new server***, you can follow [this procedure](#Procedure). If your application is deployed with git and you need to just ***update the project***, please [read this](#Demo-Commands-For-Update-Project).

## Procedure
1. [Create a new user in your CentOS](#Create-deployer-user-in-CentOS)
2. [Install Required Packages](#install-required-packages)
3. [Configure Application](#Configure-Application)
3. [Configure Supervisor](#Configure-Supervisor)
4. [Configure Application with Supervisor for making the app Up and running with log management](#Configure-Application-with-supervisor)
5. [Add the application ports in the firewall allowed port](#Add-the-application-ports-in-the-firewall-allowed-port)
6. [Viewing the server Log](#Viewing-the-server-Log)

### Create deployer user in CentOS

```console
ssh root@<ip_address>
```

Then give password.

```console
adduser [username]

passwd [username]

usermod -aG wheel [username]

exit
```

Then login again with new created user-

```console
ssh [username]@<ip_address>
```

### Install Required Packages
1. Update All existing Packages for security-

```console
sudo dnf update -y
```

##### Optional
```console
sudo dnf update kernel -y && sudo dnf install epel-release -y && sudo dnf upgrade -y

cat /etc/redhat-release
```

##### Must-Do

Install some required packages for deploy-

```console
sudo dnf install nano net-tools git wget -y
```

2. Install all required packages-

```console
sudo dnf install dotnet-sdk-3.1 aspnetcore-runtime-3.1 dotnet-runtime-3.1 supervisor -y
dotnet tool install --global dotnet-ef
```

##### If `dotnet*` not found in `install` command

```console
sudo rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
```

### Configure Application

1. Clone the project into `user` directory-
```console
cd ~ && git clone https://github.com/BCC-CA/Asp.NetCore_3.1-PostGRE_Signing-ASP.git asp && cd ./asp && git config pull.ff only
```

2. Configure Database-
```console
cp appsettings.json.example appsettings.json && nano appsettings.json
```
Then edit the `ConnectionStrings`->`DefaultConnection` section for database and edit the `SmtpSettings` section for mail settings. A demo Gmail configuration is given in `SmtpSettings_` part.

3. Migrate the database-

```console
dotnet ef database update
```

This command will create all table in the database and migrate seed data in the database. If running this command is not working, then creating the database from other source can also work.

4. Deploy the application to the `PublishedWebApp` folder in `user` folder, please provide this command-

```console
dotnet publish -c Release -o /home/abrar/PublishedWebApp
```

For the first time, it will take some time as it will download all the server side and client side libraries.

### Configure Supervisor

After the deploy command done, you will get your deployable files inside `/home/abrar/PublishedWebApp` folder. In the folder, there will be a `.dll` file named `<your_application_name>.dll` in the folder. Lets the application name is `SinedXmlVelidator`, so we will get `SinedXmlVelidator.dll` file inside the `PublishedWebApp` folder. We need to run the application with a task runner. We are using [`supervisor`](http://supervisord.org/) for that, so we need to configure ***supervisor*** for running the application. 

To make an app running with `supervisor` and configurable with `.conf` file in `/etc/supervisord.d/` directory, we need to configure supervisor like this-

```console
sudo cp /etc/supervisord.conf /etc/supervisord.conf.bak && sudo vi /etc/supervisord.conf
```

Then find the last line (shortcut can be `files = supervisord.d/*.ini`):

```console
files = supervisord.d/*.ini
```

And replace it with (keyboard key may be `i`)-

```console
files = supervisord.d/*.conf
```

Then save the file with-

```console
:wq!
```

### Configure Application with Supervisor


Before creating the service, please check the compatiblity by running the application through command line first-

```console
dotnet run  --urls "http://*:80;https://*:443"
```

##### Add the application ports in the firewall allowed port

If error occures, then try allowing port `80` and `443` in firewall by running this commands and try again-

```console
# Generate self signed SSL Certificate
sudo security set-key-partition-list -D localhost -S unsigned:,teamid:UBF8T346G9
dotnet dev-certs https

# Enable Firewall

sudo systemctl enable firewalld && sudo systemctl start firewalld && sudo systemctl status firewalld

# Add ports and https in firewall

sudo firewall-cmd --permanent --add-port=80/tcp && sudo firewall-cmd --permanent --add-port=443/tcp

# Allow services in firewall
sudo firewall-cmd --permanent --add-service=http && sudo firewall-cmd --permanent --add-service=https

# Allow the `443` port from `iptable`, `network`, `firewall` and `selinux`

sudo firewall-cmd --zone=public --add-port=80/tcp --permanent && sudo firewall-cmd --zone=public --add-port=443/tcp --permanent && sudo firewall-cmd --reload && netstat -tulnp
```

If the application is running smoothly, then try make that up and runing with supervisor.

With supervisor, you can make any application running and controll the process of the application. It supports any kind of application like python, nodejs, spring-boot or any kind of application. We will run `dotnet` application. To do this, we need to create a `.conf` file in the previously configured folder (`/etc/supervisord.d/`) with this command-

```console
sudo systemctl stop supervisord # stop supervisor server

sudo vim /etc/supervisord.d/xml_sign_asp.conf
```

If the application is running smoothly, Then paste the following configuration and save with `wq!`-

```console
[program:xml-sign-asp]
command=dotnet "StartupProject-Asp.NetCore-PostGRE.dll" --urls "http://*:80;https://*:443"
directory=/home/abrar/PublishedWebApp/
environment=ASPNETCORE__ENVIRONMENT=Development
user=root
stopsignal=INT
autostart=true
autorestart=true
startsecs=1
stderr_logfile=/var/log/xml_sign_asp.err.log
stdout_logfile=/var/log/xml_sign_asp.out.log
```

##### Restart the `supervisor` server

```console
sudo systemctl start supervisord.service && sudo systemctl enable supervisord.service && sudo supervisorctl reread && sudo supervisorctl update

sudo supervisorctl status
```

This application generates a self signed [SSL certificate](https://en.wikipedia.org/wiki/SSL) for make the website https in the application and the application will run in 443 port, so we needed to allow port 443.


## Demo Commands For Update Project

```console
cd ~/asp && sudo rm -rf ./obj ./bin && git pull && sudo systemctl stop supervisord && rm -rf ~/PublishedWebApp && dotnet publish -c Release -o ~/PublishedWebApp && sudo systemctl start supervisord && cd ~ && tail -f /var/log/xml_sign_asp.out.log
```

## Viewing the server Log

To see `application-log` file, please run this command-

```console
tail -f /var/log/xml_sign_asp.out.log
```

To see `application-error-log` file, please run this command-

```console
tail -f /var/log/xml_sign_asp.err.log
```

And to see the status of the app, please run this command-

```console
#Check if supervisor is running
sudo systemctl status supervisord

# Check status of application in supervisor
sudo supervisorctl status
```
