function traverse(selector) {
    var i = 0;
    var elements = document.querySelectorAll(selector);
    for (i = 0; i < elements.length; i+=1) {
        traverseNode(elements[i], "");
    }
    function traverseNode(node, spacing) {
        var id = node.getAttribute('id');
        var classOfNode = node.getAttribute('class');
        var output =(spacing + node.nodeName + ': ')
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

        for (var i = 0, len = node.childNodes.length; i < len; i += 1) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }
}

traverse('.birds');
