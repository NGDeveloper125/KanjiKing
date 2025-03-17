import Constants from 'expo-constants';
import * as Updates from 'expo-updates';

class UpdateService {
    static currentVersion = Constants.expoConfig?.version ?? '1.0.0';
    // Replace with your GitHub raw URL
    static versionUrl = 'https://raw.githubusercontent.com/NGDeveloper125/KanjiKing/main/version.json';

    static async checkForUpdates() {
        try {
            const response = await fetch(this.versionUrl);
            
            if (!response.ok) {
                throw new Error('Failed to check for updates');
            }

            const data = await response.json();
            const isUpdateAvailable = data.latestVersion > this.currentVersion;

            if (isUpdateAvailable) {
                const update = await Updates.checkForUpdateAsync();
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