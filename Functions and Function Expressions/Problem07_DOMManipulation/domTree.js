var domModule = (function() {

    function appendChild(element, child) {
        var i = 0;
        child = returnArray(child);
        for (i = 0; i< child.length ; i+=1) {
            child[i].appendChild(element);
        }
    }

    function removeChild(element, child) {
        var i = 0;
        var j = 0;
        var childToRemove;
        element = returnArray(element);
        child = returnArray(child);
        for (i = 0; i< element.length ; i+=1) {
            for (j = 0; j< child.length ; j+=1) {
                element[i].removeChild(child[j]);
            }
        }
    }

    function addHandler(element, eventType, eventHandler) {
        var i = 0;
        element = returnArray(element);
        for (i = 0; i< element.length ; i+=1) {
            element[i].addEventListener(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        var result = returnArray(selector);
        return result;
    }

    function returnArray(variable) {
        if (typeof (variable) == "string") {
            variable = document.querySelectorAll(variable);
        } else {
            variable = [variable];
        }

        return variable;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
})();

//var liElement = document.createElement("li");
//domModule.appendChild(liElement,".birds-list");
//domModule.removeChild("ul.birds-list","li:first-child");
//domModule.addHandler("li.bird", 'click', function(){ alert("I'm a bird!") });
var elements = domModule.retrieveElements(".bird");
var i = 0;
for (; i < elements.length; i+=1) {
    console.log(elements[i]);
}