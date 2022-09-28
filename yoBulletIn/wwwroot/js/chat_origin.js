"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, itemId) {
    var li = document.createElement("li");

    var thisItemId = document.getElementById("itemId").value;
    var commentsList = document.getElementById("messagesList");
    if (itemId == thisItemId) {
            commentsList.appendChild(li);
            li.textContent = `${user}: ${ message }`;
            
            commentsList.scrollTop = commentsList.scrollHeight;

            var badgeCounterSpan = document.getElementById("badgeCounter");
            var badgeCounter = badgeCounterSpan.innerHTML;
            badgeCounter++;
            badgeCounterSpan.innerHTML = badgeCounter;

            if (badgeCounterSpan.innerHTML > 0) {
                badgeCounterSpan.style.visibility = "visible";
            }
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var itemId = document.getElementById("itemId").value;
    var itemOwner = document.getElementById("itemOwner").value;

    // adding message to the DB
    $.ajax({
        type: "POST",
        url: "/ItemCart/AddComment",
        data: { "ItemId": itemId, "message": message, "user": user }
    });

    document.getElementById("messageInput").value = '';

    connection.invoke("SendMessage", user, itemOwner, message, itemId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});