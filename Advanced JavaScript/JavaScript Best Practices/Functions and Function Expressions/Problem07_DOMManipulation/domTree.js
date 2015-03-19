var domModule = (function() {

    function appendChild(element, child) {
        var i = 0,
            len;

        child = returnArray(child);
        len = child.length;

        for (i = 0; i < len ; i+=1) {
            child[i].appendChild(element);
        }
    }

    function removeChild(element, child) {
        var i = 0,
            j = 0,
            childToRemove,
            elementsLength,
            childrenLength;

        element = returnArray(element);
        child = returnArray(child);
        elementsLength = element.length;
        childrenLength = child.length;

        for (i = 0; i < elementsLength ; i+=1) {
            for (j = 0; j< childrenLength ; j+=1) {
                element[i].removeChild(child[j]);
            }
        }
    }

    function addHandler(element, eventType, eventHandler) {
        var i = 0,
            elementLength;

        element = returnArray(element);
        elementLength = element.length;

        for (i = 0; i < elementLength ; i+=1) {
            element[i].addEventListener(eventType, eventHandler);
        }
    }

    function retrieveElements(selector) {
        var result = returnArray(selector);
        return result;
    }

    function returnArray(variable) {
        if (typeof (variable) == 'string') {
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

var liElement = document.createElement('li');
domModule.appendChild(liElement,'.birds-list');
domModule.removeChild('ul.birds-list','li:first-child');
domModule.addHandler('li.bird', 'click', function(){ alert('I\'m a bird!') });
var elements = domModule.retrieveElements('.bird');
var i = 0;
for (; i < elements.length; i+=1) {
    console.log(elements[i]);
}