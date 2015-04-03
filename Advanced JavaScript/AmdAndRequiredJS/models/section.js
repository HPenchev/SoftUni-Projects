    define(function(){
        var Section = (function () {
            function Section(text) {
                this.title = text;
                this.items = [];
            }

            Section.prototype.addToDOM = function(container) {
                var list;
                var listElement;
                var section;
                var textnode;
                var title;
                var ul;
                var textInput;
                var button;
                var textBox;
                var that = this;
                list = container.getElementsByTagName('ul')[0];
                listElement = document.createElement('li');
                listElement.setAttribute('class', 'section');

                section = document.createElement('section');

                textnode = document.createTextNode(this.title);
                title = document.createElement('h2');
                title.setAttribute('class', 'title');
                title.appendChild(textnode);

                ul = document.createElement('ul');

                textInput = document.createElement('input');
                textInput.setAttribute('type', 'text');
                textInput.setAttribute('class', 'item-description');
                textInput.setAttribute('placeholder', 'Add item...');

                button = document.createElement('input');
                button.setAttribute('type', 'button');
                button.setAttribute('value', '+');
                button.addEventListener('click', function() {
                    var sectionButton = this;
                    console.log(this);

                    require(['factory'], function (Factory) {
                        Factory.createNewItem(sectionButton.parentNode, that);
                    })
                });

                section.appendChild(title);
                section.appendChild(ul);
                section.appendChild(textInput);
                section.appendChild(button);

                listElement.appendChild(section);

                list.appendChild(listElement);
            };

            Section.prototype.cleanArray = function (items, prototype) {
                var i = 0;
                var temp;
                for (i = 0; i < items.length; i+=1) {
                    if (typeof items[i] != 'object' || Object.getPrototypeOf(items[i]) !== prototype) {
                        items.splice(i, 1);
                        i--;
                    }
                }
            };

            return Section;
        }());

        return Section;
    });