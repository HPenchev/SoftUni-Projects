function traverse(selector) {
    var i = 0,
        elements = document.querySelectorAll(selector),
        elementsLength = elements.length;

    function traverseNode(node, spacing) {
        var id = node.getAttribute('id'),
            classOfNode = node.getAttribute('class'),
            output =(spacing + node.nodeName + ': '),
            len = node.childNodes.length,
            i,
            child;

        if (id) {
            output += 'id="';
            output += id;
            output += '"';
        }

        if (classOfNode) {
            output += ' class="';
            output += classOfNode;
            output += '"';
        }

        console.log(output);
        spacing = spacing || '  ';

        for (i = 0; i < len; i += 1) {
            child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }

    for (i = 0; i < elementsLength; i+=1) {
        traverseNode(elements[i], '');
    }
}

traverse('.birds');
