function insert (selector, element, position) {
    var $selectedElement = $(selector),
        $elementToAdd = $(element);
    if (position === 'before') {
        $selectedElement.preppend($elementToAdd);
    }

    if (position === 'after') {
        $selectedElement.append($elementToAdd);
    }
}

insert('li:first', '<li>sparrow</li>', 'after' );