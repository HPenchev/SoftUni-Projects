define(function(){
    var Container = (function () {
        function Container() {
            this.sections = [];
        }

        Container.prototype.addToDOM = function () {
            var main;
            var list;
            var inputText;
            var button;
            var wrapper;

            var _this = this;

            main = document.getElementById('main');

            wrapper = document.createElement('div');

            list = document.createElement('ul');
            wrapper.appendChild(list);
            main.appendChild(wrapper);

            inputText = document.createElement('input');
            inputText.setAttribute('type', 'text');
            inputText.setAttribute('class', 'section-adder');
            inputText.setAttribute('placeholder', 'Title...');
            main.appendChild(inputText);

            button = document.createElement('input');
            button.setAttribute('type', 'button');
            button.setAttribute('value', 'New Section');
            button.setAttribute('id', 'section-adder');
            button.addEventListener('click', function() {
                var containerButton = this;

                require(['factory'], function(Factory) {

                    Factory.createNewSection(containerButton.parentNode, _this);
                })
            });
            // button.setAttribute('onclick', 'javascript: toDoList.createNewSection(this.parentNode);');
            main.appendChild(button);
            //document.getElementById('section-adder').addEventListener('click',alert('test'));
        };

        return Container;
    })();

    //function createNewSection(containerDOM) {
    //    var textBox;
    //    var input;
    //    var sectionToAdd;
    //
    //    textBox = containerDOM.getElementsByClassName('section-adder')[0];
    //    input = textBox.value;
    //
    //    console.log(this);
    //    if (!input) {
    //        return;
    //    }
    //
    //    require(['section', 'htmlLoader'], function (section, htmlLoader) {
    //        sectionToAdd = Object.create(section);
    //        sectionToAdd.constructor(input);
    //        console.log(that)
    //    });
    //
    //    sectionToAdd.addToDOM(containerDOM);
    //
    //    textBox.value = "";
    //}

    return Container;

});
