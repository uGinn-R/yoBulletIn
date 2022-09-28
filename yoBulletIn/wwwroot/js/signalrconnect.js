"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var sendButton = document.getElementById("sendButton");
if (sendButton != null) {
    sendButton.disabled = true;
}
connection.on("ReceiveMessage", function (user, message, itemId) {

    var badgeCounterSpan = document.getElementById("badgeCounter");
    if (badgeCounterSpan != null) {
        badgeCounterSpan.style.visibility = "visible";

        badgeCounterSpan.innerHTML = "You have new message";
    }     
});

connection.start().then(function () {
    if (sendButton != null) {
        sendButton.disabled = true;
    }
}).catch(function (err) {
    return console.error(err.toString());
});
