define('item', [], function() {
    var Item = (function() {
        function Item(content, isCompleted) {
            this.content = content;
            this.isCompleted = isCompleted;
        }

        Item.prototype.addToDOM = function(section) {
            var list;
            var listElement;
            var checkBox;
            var textnode;
            var div;

            var that = this;
            list = section.getElementsByTagName('ul')[0];

            listElement = document.createElement('li');
            listElement.setAttribute('class', 'item');
            checkBox = document.createElement('input');
            checkBox.setAttribute('type', 'checkbox');
            checkBox.addEventListener('change', function() {
                completedStatusChange(this.checked, this.parentNode, that);
            });
            textnode = document.createTextNode(this.content);

            div = document.createElement('div');
            div.setAttribute('class', 'inner-div');
            div.appendChild(textnode);

            listElement.appendChild(checkBox);
            listElement.appendChild(div);

            list.appendChild(listElement);
        };

        function completedStatusChange(isChecked, itemDOM, item) {
            var innerDiv;
            innerDiv = itemDOM.getElementsByClassName('inner-div')[0];
            item.isCompleted = isChecked;
            colorChange(item.isCompleted, innerDiv);
        }

        function colorChange(isCompleted, innerDiv) {
            if(isCompleted) {
                innerDiv.style.background = 'lightgreen';
            } else {
                innerDiv.style.background = 'white';
            }
        }

        return Item;
    }());

    return Item;
});
