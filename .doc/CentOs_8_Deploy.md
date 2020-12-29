# Complete ASP.Net Core deploy in Centos 8

If you need to ***deploy the whole project in a new server***, you can follow [this procedure](#Procedure). If your application is deployed with git and you need to just ***update the project***, please [read this](#Demo-Commands-For-Update-Project).

## Procedure
1. [Create a new user in your CentOS](#Create-deployer-user-in-CentOS)
2. [Install Required Packages](#install-required-packages)
3. [Configure Application](#Configure-Application)
3. [Configure Supervisor](#Configure-Supervisor)
4. [Configure Application with Supervisor for making the app Up and running with log management](#Configure-Application-with-supervisor)
5. [Add the application ports in the firewall allowed port](#Add-the-application-ports-in-the-firewall-allowed-port)

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
Update package-

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

##### Optional
Add package repo for Centos 8 (not needed in maximum time)-

```console
sudo rpm -Uvh https://packages.microsoft.com/config/centos/8/packages-microsoft-prod.rpm
```

2. Install all required packages-

```console
sudo dnf install dotnet-sdk-3.1 aspnetcore-runtime-3.1 dotnet-runtime-3.1 supervisor -y
```

### Configure Application

1. Clone the project into `user` directory-
```console
cd ~ && git clone https://github.com/BCC-CA/Asp.NetCore_3.1-PostGRE_Signing-ASP.git asp && cd ./asp
```

2. Configure Database-
```console
cp appsettings.json.example appsettings.json && nano appsettings.json
```
Then edit the `ConnectionStrings`->`DefaultConnection` section for database and edit the `SmtpSettings` section for mail settings. A demo Gmail configuration is given in `SmtpSettings_` part.

3. Deploy the application to the `PublishedWebApp` folder in `user` folder, please provide this command-

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

With supervisor, you can make any application running and controll the process of the application. It supports any kind of application like python, nodejs, spring-boot or any kind of application. We will run `dotnet` application. To do this, we need to create a `.conf` file in the previously configured folder (`/etc/supervisord.d/`) with this command-

```console
sudo systemctl stop supervisord # stop supervisor server

sudo vim /etc/supervisord.d/xml_sign_asp.conf
```

Then paste the following configuration and save with `wq!`-

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

### Add the application ports in the firewall allowed port

This feature is ***optional***. We allow the `443` port from `iptable`, `network`, `firewall` and `selinux`.

```console
sudo firewall-cmd --zone=public --add-port=443/tcp --permanent && sudo firewall-cmd --reload && netstat -tulnp
```

This application generates a self signed [SSL certificate](https://en.wikipedia.org/wiki/SSL) for make the website https in the application and the application will run in 443 port, so we needed to allow port 443.


## Demo Commands For Update Project

```console
cd ~/asp && git pull && sudo systemctl stop supervisord && rm -rf ~/PublishedWebApp && dotnet publish -c Release -o ~/PublishedWebApp && sudo systemctl start supervisord && cd ~ && tail -f /var/log/xml_sign_asp.out.log
```
