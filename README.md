# Kerk en IT Backup app
App to backup files and folders at shutdown.

# Setup
Download the app [backup.exe](https://github.com/kerkenit/nl.kerkenit.backup/releases/download/v1.1.0/Backup.exe)

Run the app normaly and add all backup locations

# Unattended usage
- Run **Win+R**
- Type **gpedit.msc**
- Naviage to: **Local Computer Policy** > **Windows Settings** > **Scripts (Startup/Shutdown)** > **Shutdown**
- Browse to the folder where this app is running and select **Backup.exe**
- Give as script parameters **backup 30** *(Means to leave 30 folders in the backup folder)*
- Press **OK**
- Press **OK**
- Close all Windows and reboot
