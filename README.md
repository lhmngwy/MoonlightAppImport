# MoonlightAppImport

A [Playnite](https://github.com/JosefNemec/Playnite) plugin that imports games from a [Sunshine](https://github.com/LizardByte/Sunshine) or [Apollo](https://github.com/ClassicOldSong/Apollo) host and launches them directly with [Moonlight](https://github.com/moonlight-stream/moonlight-qt).  

Once configured, you never need to open the Moonlight UI again, except to tweak stream-quality settings.

Picture this: A tiny living-room PC boots straight into Playnite’s Fullscreen mode. From the couch, you browse your library with a controller, hit *Play*, and the Moonlight stream starts automatically. When you quit the game, the stream ends and Playnite regains focus, ready for the next title. It’s a console-style experience entirely within Playnite.

---

## Features
- Supports **both** Sunshine and Apollo hosts.  
- Imports host apps and launches them directly in Moonlight. No Moonlight UI required.  
- Stores your Sunshine password **encrypted** with Windows DPAPI.  

---

## Installation

1. Download the latest `MoonlightAppImport_60ea0079-bf4b-417c-a1f3-d5470ec5e96b_<version>.pext` from the [releases page](https://github.com/SolemnDucc/MoonlightAppImport/releases).  
2. In Playnite open **Library ▸ Configure Integrations ▸ Moonlight App Import**.  
3. Set the full path to `Moonlight.exe` (e.g. `C:\Program Files\Moonlight Game Streaming\Moonlight.exe`).  
4. Enter the Sunshine host address (e.g. `192.168.1.69`).  
5. Enter your Sunshine username.  
6. Enter your Sunshine password (stored encrypted).  
7. Enable **“Use Apollo instead of Sunshine”** if applicable.  
8. Enable **“Allow self-signed certificate”** if your host uses the default, self-signed TLS cert (the common case).  
9. Run **Library ▸ Update Game Library ▸ Moonlight App Import**.  
10. The plugin fetches all configured apps from the host and adds them to Playnite.

---

## Best-practice setup

I suggest the following setup:
- A Server with [Apollo](https://github.com/ClassicOldSong/Apollo), [Playnite](https://github.com/JosefNemec/Playnite) and the plugins [SunshineAppExport](https://github.com/MichaelMKenny/SunshineAppExport) and [PlayNiteWatcher](https://github.com/Nonary/PlayNiteWatcher).
- A Client with [Moonlight](https://github.com/moonlight-stream/moonlight-qt), [Playnite](https://github.com/JosefNemec/Playnite) and [MoonlightAppImport](https://github.com/SolemnDucc/MoonlightAppImport/)

Typical workflow:

1. **Install** the game on the server.  
2. **Add** it to Playnite (server side).  
3. **Export** it to Apollo via *SunshineAppExport*.  
4. On the **client**, update the library with *MoonlightAppImport*.  
5. **Play** the game from Playnite on the client.

Enjoy couch-friendly game streaming without leaving Playnite!
