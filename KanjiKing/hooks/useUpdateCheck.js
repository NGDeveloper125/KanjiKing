import { useState } from 'react';
import { Alert, Linking } from 'react-native';
import UpdateService from '../Services/UpdateService';

export const useUpdateCheck = () => {
    const [isChecking, setIsChecking] = useState(false);

    const checkForUpdates = async () => {
        setIsChecking(true);
        try {
            const updateInfo = await UpdateService.checkForUpdates();
            
            if (updateInfo.isUpdateAvailable) {
                Alert.alert(
                    'Update Available',
                    `A new version (${updateInfo.version}) is available. Would you like to update now?`,
                    [
                        {
                            text: 'Later',
                            style: 'cancel',
                        },
                        {
                            text: 'Update',
                            onPress: () => {
                                if (updateInfo.updateUrl) {
                                    Linking.openURL(updateInfo.updateUrl);
                                }
                            },
                        },
                    ]
                );
            }
        } finally {
            setIsChecking(false);
        }
    };

    return { checkForUpdates, isChecking };
};