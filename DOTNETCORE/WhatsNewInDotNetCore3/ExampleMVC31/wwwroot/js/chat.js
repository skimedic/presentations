"use strict";

var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect()
    //.withAutomaticReconnect([0, 3000, 5000, 10000, 15000, 30000])
    //.withAutomaticReconnect([0, 2000, 10000, 30000]) The default intervals.
    .build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    var cid = '';
    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            cid = connectionId;
            document.getElementById("connectionStatus").innerText = 'Connected: ' + cid;
        });
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


connection.onreconnecting((error) => {
    var status = 'Connection lost due to error: ' + error + '. Reconnecting.';
    document.getElementById("messageInput").disabled = true;
    document.getElementById("sendButton").disabled = true;
    document.getElementById("connectionStatus").innerText = status;
});

connection.onreconnected((connectionId) => {
    var status = 'Connection reestablished. Connected';
    document.getElementById("messageInput").disabled = false;
    document.getElementById("sendButton").disabled = false;
    document.getElementById("connectionStatus").innerText = status + ": " + connectionId;
});