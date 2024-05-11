# KanjiKing
Kanji Memory Game


## Deployment Instructions for Blazor WebAssembly Frontend (Offline Host on Mobile Phone)

## Publish the Blazor WebAssembly Project:

1. In Visual Studio, right-click on your Blazor WebAssembly project in the Solution Explorer.
2. Select "Publish" from the context menu.
3. Choose "Folder" as the publish target and specify the output directory.
4. Click "Publish" to generate the published files.

## Copy Published Files to Your Android Device:

1. Connect your Android device to your computer using a USB cable.
2. Enable file transfer mode on your Android device.
3. Copy the entire contents of the published output directory to a folder on your Android device.

## Install a Web Server App on Your Android Device:

1. Open the Google Play Store on your Android device.
2. Search for a web server app that allows you to host static files (e.g., "Web Server for Android" or "Simple HTTP Server").
3. Install the web server app on your Android device.

## Configure the Web Server App:

1. Open the web server app on your Android device.
2. Set the root directory to the folder where you copied the published files.
3. Start the web server.

## Access the Application on Your Android Device:

1. Open a web browser on your Android device.
2. Enter the URL provided by the web server app (usually in the format http://localhost:port).
3. The Blazor WebAssembly application should load and run in the browser.

## Install as a Progressive Web App (PWA) (Optional):

1. When you access the application URL in the browser, you should see an option to "Add to Home Screen" or install the app.
2. Tap on that option to install the application as a PWA on your Android device.
3. Once installed, the application will have an app-like experience and can be launched from the home screen.

## Offline Support:

- Since your application is designed to work offline, ensure that you have implemented the necessary caching mechanisms.
- Blazor WebAssembly uses the `service-worker.js` file to enable offline support.
- Make sure that the `service-worker.js` file is present in the published output and is correctly registered in the `index.html` file.

By following these steps, you can host your Blazor WebAssembly application on your Android device using a web server app. The application will be accessible through the browser on your device and can be installed as a PWA for an app-like experience. Since the JSON file used as a database is bundled with the application, it will work offline without the need for a server-side component.
