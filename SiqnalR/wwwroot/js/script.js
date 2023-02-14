const connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

connection.on("Send", function(user, message, time){
    let messElem = document.createElement("p");
    messElem.appendChild(document.createTextNode(time + " " + user + ": " + message));
    let firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(messElem, firstElem);
});

// document.getElementById("sendBtn").addEventListener("click", function(ev){
//     let message = document.getElementById("message").value;
//     let user = document.getElementById("user").value;
//     connection.invoke("Send", user, message);
// });

document.getElementById("sendBtn").addEventListener("click", function(ev){
    let message = document.getElementById("message").value;
    let user = document.getElementById("user").value;
    let users = [];
    document.querySelectorAll(".userCheck").forEach((elem)=>{
        if(elem.checked)
        {
            users.push(elem.nextElementSibling.value);
        }
    });
    connection.invoke("SendToUsers", users, message, user);
});

connection.on("SendToUsers", function(user, message, time){
    let messElem = document.createElement("p");
    messElem.appendChild(document.createTextNode(time + "   " + user + ": " + message));
    let firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(messElem, firstElem);
});

connection.start();