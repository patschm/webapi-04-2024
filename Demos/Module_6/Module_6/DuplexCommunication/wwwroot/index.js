export const hubUrl = "https://ps-ircii.azurewebsites.net/irc";
let _nickname;
let _channel;

// Create a connection to the hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl)
    .configureLogging(signalR.LogLevel.Information)
    .build();

export function register(nick, messageCallback, joinCallback) {
    _nickname = nick;
    // Define a function to handle received messages
    connection.on("Message", (nickname, message) => {
        messageCallback(nickname, message)
    });
    connection.on("Join", (nickname, channel) => {
        joinCallback(nickname, channel);
    });

    // Start the connection
    connection.start()
        .then(() => {
            console.log("Connection established");
        })
        .catch((err) => {
            console.error("Error establishing connection:", err);
        });
}

export function join(channel) {
    _channel = channel
    connection.invoke("join", _nickname, _channel)
}
export function send(text) {
    connection.invoke("sendmessage", _nickname, _channel, text);
}