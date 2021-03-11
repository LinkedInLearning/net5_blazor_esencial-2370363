window.playAudio = (audio) => { audio.play(); };
window.setMessage = (componentRef) =>
{
	componentRef.invokeMethodAsync('SetMessageFromCSharp', 'El mensaje lo ha enviado Javascript.')
		.then((returnedValue) => {
			console.log("El texto devuelto desde .net es: " + returnedValue + ".");
	});
	
};
