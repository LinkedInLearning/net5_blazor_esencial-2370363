window.playAudio = (audio) => { audio.play(); };
window.setMessage = () =>
{
	var value = DotNet.invokeMethodAsync('StoriesLibrary.Client', 'SetMessageFromCSharp', 'El mensaje lo ha enviado Javascript.').then((returnedValue) => {
		returnedValue;
	});
	console.log("El texto devuelto desde .net es: " + value + ".");
};
