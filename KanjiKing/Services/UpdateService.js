import Constants from 'expo-constants';
import * as Updates from 'expo-updates';

class UpdateService {
    static currentVersion = Constants.expoConfig?.version ?? '1.0.0';
    // Replace with your GitHub raw URL
    static versionUrl = `https://raw.githubusercontent.com/NGDeveloper125/KanjiKing/main/version.json?t=${Date.now()}`;

    static async checkForUpdates() {
        try {
            console.log('Current Version:', this.currentVersion);
            const response = await fetch(this.versionUrl);
            
            if (!response.ok) {
                throw new Error('Failed to check for updates');
            }
    
            const data = await response.json();
            console.log('Latest Version from server:', data.latestVersion);
            const isUpdateAvailable = data.latestVersion > this.currentVersion;
            console.log('Update available:', isUpdateAvailable);
    
            if (isUpdateAvailable) {
                console.log('Checking for Expo update...');
                const update = await Updates.checkForUpdateAsync();
                console.log('Expo update available:', update.isAvailable);
                if (update.isAvailable) {
                    await Updates.fetchUpdateAsync();
                    await Updates.reloadAsync();
                }
            }
    
            return {
                version: data.latestVersion,
                isUpdateAvailable,
                updateUrl: data.updateUrl,
            };
        } catch (error) {
            console.error('Error checking for updates:', error);
            return {
                version: this.currentVersion,
                isUpdateAvailable: false,
            }
        }
    }
}

export default UpdateService;