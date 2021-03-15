window.accessibilityFunctions = {
	focus: function (element) {
		if (element === null || element === undefined) {
			return false;
		}

		if (element.tagName !== "INPUT" && element.tagName !== "BUTTON" && element.tagName !== "A") {
			var attributeValue = element.getAttribute("tabindex");
			if (attributeValue === null || attributeValue === "" || attributeValue === "0") {
				element.setAttribute("tabindex", "-1");
			}
		}
		return element.focus();
	},

	focusByQuerySelector: function (selector) {
		var element = document.querySelector(selector);
		if (element !== null) {
			return accessibilityFunctions.focus(element);
		}
		return false;
	},

	focusInHeader: function (level = null) {
		var selector = level === null ? "h1, h2, h3, h4, h5, h6" : "h" + level;
		// alert(selector);
		// navigator.clipboard.writeText(document.documentElement.innerHTML);
		var element = document.querySelector(selector);
		if (element !== null) {
			return accessibilityFunctions.focus(element);
		}
	}
}