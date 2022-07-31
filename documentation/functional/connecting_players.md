# Connecting Players

Connecting to other players is vital for the game play. Adding players should be as seamless and reliable as possible. All supported platforms can connect to each other. Other players can connect both locally and globally, using either WiFi, the internet or bluetooth.

The player who initiates a server session in the game, in any game mode, is known as the `lead player`. They act as the game server and administrator, both approving players to join and being able to remove players from the server session.

## Server Session

The lead player [creates a server session](screens/server_session_create.md) when the game starts. This session generates a unique code that can be given to other players for them to connect. Each player connecting is required to enter a player name. The lead player must explicitly approve a player's connection request for them to connect.

If the lead player ends the server session, all connected players are automatically disconnected.

Only the lead player is able to control the game. Connected players will see the results of the lead player's selections. Once a game level is started, the connected players will be able to play as normal.

## Client Session

A player can [join a server session](screens/server_session_join.md) by entering the server code given by the lead player. The client is required to enter a player name. If the lead player approves the connection request, the client is connected to the server session.

The following optional information can also be set by a client:

* [Avatar](avatars.md)

Any optional information not set by a client will be randomly selected by the server session.

If a client gets disconnected due to network connection issues, the client will try to reconnect to the server session and will join the kitchen lobby.

A client can disconnect from a server session at any time.
