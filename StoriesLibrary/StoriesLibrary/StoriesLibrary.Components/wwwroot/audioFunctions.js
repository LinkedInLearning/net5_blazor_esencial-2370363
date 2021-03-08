export function playAudio(audioElement) {
	audioElement.play();
}

export function stopAudio(audioElement) {
	audioElement.pause();
	audioElement.currentTime = 0;
}
