"use strict";

//Disable the send button until connection is established.

connection.on("ReceiveMessage", function (user, message, itemId) {
    var commentsList = document.getElementById("messagesList");
    if (commentsList != null) {
        var li = document.createElement("li");

        var thisItemId = document.getElementById("itemId").value;

        if (itemId == thisItemId) {
            commentsList.appendChild(li);
            li.textContent = `${user}: ${message}`;

        }
    }
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