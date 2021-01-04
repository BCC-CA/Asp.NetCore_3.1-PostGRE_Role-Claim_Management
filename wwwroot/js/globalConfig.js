// Global Configuration
$(document).ready(function () {
	$.support.cors = true;

	$('.DatePicker').datepicker({
		format: "mm/dd/yyyy",
		autoclose: true,
		//title: "Select BD",
		todayHighlight: true,
		//startView: 'decade',
		weekStart: 6
	});

	// extend range validator method to treat checkboxes differently
	$.validator.methods.range = function (value, element, param) {
		if (element.type === 'checkbox' && element.classList.contains("must-check")) {
			// if it's a checkbox return true if it is checked
			return element.checked;
		} else {
			// otherwise run the default validation function
			return $.validator.methods.range.call(this, value, element, param);
		}
	}


	//Digital Signature - Start
	function signProcessStartEvent(htmlElement) {
		console.log("Sign Started", new Date());
	}

	function signProcessContinueEvent(htmlElement) {
		console.log("Sign Continue", (new Date()).getUTCMilliseconds());
	}

	function signProcessEndEvent(htmlElement, status = true) {
		if (status) {
			var signatureText = htmlElement.getAttribute('signed-xml');
			htmlElement.removeAttribute('signed-xml');
			var signatureId = htmlElement.getAttribute('sign-server-id');
			console.log("Sign Done", new Date());

			//Make your AJAX call here
			$.ajax({
				url: htmlElement.getAttribute('sign-ajax-url'),
				type: "post",
				data: {
					id: htmlElement.getAttribute('sign-server-id'),
					toSignXml: htmlElement.getAttribute('sign-xml'),
					signedXml: signatureText
				},
				success: function (response) {
					console.log(response);
					alert("File Signed and uploaded");
				},
				error: function (jqXHR, textStatus, errorThrown) {
					console.log(textStatus, errorThrown);
				}
			});
			console.log(htmlElement);
		} else {
			console.log(htmlElement, "Sign Failed", new Date());
		}

	}

	function startSignProcess(htmlElement) {
		signProcessStartEvent(htmlElement);
		var startTime = (new Date()).getTime();
		var timeInterval = setInterval(function () {
			signProcessContinueEvent(htmlElement);
			if (htmlElement.getAttribute('signed-xml')) {
				clearInterval(timeInterval);
				signProcessEndEvent(htmlElement);
				var endTime = (new Date()).getTime();
				console.log("Needed Signing Time (ms)", endTime - startTime);

			}
		}, 100);
		setTimeout(() => {
			clearInterval(timeInterval);
			signProcessEndEvent(htmlElement, false);
		}, 600000);//10 min wait
	}

	function setSignProcessListener(htmlElement) {
		htmlElement.addEventListener("click", function () {
			console.log("Process Started!");
			startSignProcess(htmlElement);
		});
	}
	for (let item of document.getElementsByClassName("btn-digital-sign")) {
		setSignProcessListener(item);
	}
	//Digital Signature - End
});