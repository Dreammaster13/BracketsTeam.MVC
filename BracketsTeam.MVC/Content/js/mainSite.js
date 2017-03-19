$(function () {
    /*$('[data-toggle="tooltip"]').tooltip({
        html: true
    });*/
})

var intervalCounter;

function ShowAlertMessage(title, content, duration, useHTML, cssClass) {
    if (typeof title === "undefined") { title = "Placeholder:"; }
    if (typeof content === "undefined") { content = "Placeholder"; }
    if (typeof duration === "undefined") { duration = 5; }
    if (typeof useHTML === "undefined") { useHTML = false; }
    if (typeof cssClass === "undefined") { cssClass = "info"; }

    $("#msg-title").text(title);

    if (useHTML) $("#msg-content").html(content);
    else $("#msg-content").text(content);

    $("#alertMessage").removeClass().addClass("alert alert-" + cssClass).slideDown(600);

    HideAlertMessage(duration);
}

function HideAlertMessage(hideSeconds) {
    var countdown = hideSeconds;
    clearInterval(intervalCounter);

    intervalCounter = setInterval(function () {
        countdown--;
        if (countdown == 0) {
            $("#alertMessage").slideUp(600);
            clearInterval(intervalCounter);
        }
    }, 1000);
}