
var callback = function () {
    //Executes after everything is loaded and parsed:
    window.addEventListener("load", function () {
        document.getElementsByClassName("select-label")[0].firstChild.innerHTML = "انتخاب نسخه سرویس";
        var LogoLink = document.getElementsByClassName("topbar-wrapper")[0].getElementsByClassName("link")[0];
        var LogoElement = LogoLink.firstChild;
        LogoElement.setAttribute("src", "/Swagger-ui/Images/CentralInsurance.png");
        var LogoTitleElement = document.createElement("span");
        //LogoTitleElement.innerText = "سلامت افزار پارس شریف";
        LogoTitleElement.innerText = "";
        LogoTitleElement.setAttribute("class", "LogoTitle");
        LogoLink.appendChild(LogoTitleElement);
    });
};

if (document.readyState === "complete" || (document.readyState !== "loading" && !document.documentElement.doScroll)) {
    callback();
} else {
    document.addEventListener("DOMContentLoaded", callback);
}