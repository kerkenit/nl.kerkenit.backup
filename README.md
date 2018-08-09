# Kerk en IT Backup app
App to backup files and folders at shutdown.

# Setup
- Run the app normaly and add all backup locations

# Unattended usage
- Run **Win+R**
- Type **gpedit.msc**
- Naviage to: **Local Computer Policy** > **Windows Settings** > **Scripts (Startup/Shutdown)** > **Shutdown**
- Browse to the folder where this app is running and select **Backup.exe**
- Give as script parameter **backup*
- Press **OK**
- Press **OK**
- Close all Windows and reboot
