
window.playAudio = function(audioId, audioUrl) {
    var audio = document.getElementById(audioId);
    audio.src = audioUrl;
    audio.play();
};