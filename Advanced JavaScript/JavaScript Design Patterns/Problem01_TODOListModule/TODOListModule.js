var toDoList = (function() {
    var ItemPrototype = {
        constructor: function(content, isCompleted) {
            if (typeof (content) != "string") {
                throw  new Error("Content has to be a string");
            }

            if (isCompleted && typeof (isCompleted != "boolean")) {
                throw new Error ("isCompleted status has to be boolean");
            }

            this.content = content;
            this.isCompleted = isCompleted;
            if (!isCompleted) {
                this.isCompleted = false;
            }
        },
        addToDOM: function(section){
            var list;
            var listElement;
            var checkBox;
            var textnode;
            var div;

            list = section.getElementsByTagName('ul')[0];

            listElement = document.createElement('li');
            listElement.setAttribute('class', 'item');
            checkBox = document.createElement('input');
            checkBox.setAttribute('type', 'checkbox');
            checkBox.setAttribute('onchange', 'javascript: toDoList.completedStatusChange(this.checked, this.parentNode);');
            textnode = document.createTextNode(this.content);

            div = document.createElement('div');
            div.setAttribute('class', 'inner-div');
            div.appendChild(textnode);

            listElement.appendChild(checkBox);
            listElement.appendChild(div);

            list.appendChild(listElement);
        }
    }

    var SectionPrototype = {
        constructor: function(title, items) {
            if (typeof (title) != "string") {
                throw  new Error("Content has to be a string");
            }

            if(!items || items.constructor !== Array) {
                this.items = [];
            } else {
                cleanArray(items, ItemPrototype);
                this.items = items;
            }

            this.title = title;
        },
        addToDOM: function(container){
            var list;
            var listElement;
            var section;
            var textnode;
            var title;
            var ul;
            var textInput;
            var button;
            var textBox;

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
            button.setAttribute('onclick', 'javascript: toDoList.addNewItem(this.parentNode);');

            section.appendChild(title);
            section.appendChild(ul);
            section.appendChild(textInput);
            section.appendChild(button);

            listElement.appendChild(section);

            list.appendChild(listElement);
        }
    }

    var ContainerPrototype = {
        constructor: function(sections) {
            if(!sections || sections.constructor !== Array) {
                this.sections = [];
            } else {
                cleanArray(sections, SectionPrototype);
                this.sections = sections;
            }
        },
        addToDOM: function(){
            var main;
            var list;
            var inputText;
            var button;
            var wrapper;

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
            button.setAttribute('onclick', 'javascript: toDoList.createNewSection(this.parentNode);');
            main.appendChild(button);
        }
    }

    function cleanArray(items, prototype) {
        var i = 0;
        var temp;
        for (i = 0; i < items.length; i+=1) {
            if (typeof items[i] != 'object' || Object.getPrototypeOf(items[i]) !== prototype) {
                items.splice(i, 1);
                i--;
            }
        }
    }

    function createNewSection(containerDOM) {
        var textBox;
        var input;
        var section;

        textBox = containerDOM.getElementsByClassName('section-adder')[0];
        input = textBox.value;

        if (!input) {
            return;
        }

        section = Object.create(toDoList.SectionPrototype);
        section.constructor(input);
        container.sections.push(section);

        section.addToDOM(containerDOM);

        textBox.value = "";
    }


    function addNewItem(section) {
        var textbox;
        var input;
        var containingSection;
        var nameSearched;
        var item;

        textbox = section.getElementsByClassName('item-description')[0];
        input = textbox.value;

        if(!input) {
            return;
        }

        nameSearched = section.getElementsByClassName('title')[0].innerText;
        //var test = nameSearched.value;

        containingSection = (function test() {
            for (var sectionInContainer in container.sections) {
                if (container.sections[sectionInContainer].title === nameSearched) {
                    return container.sections[sectionInContainer];
                }
            }
        })();

        item = Object.create(toDoList.ItemPrototype);
        item.constructor(input);

        containingSection.items.push(item);

        textbox.value = '';

        item.addToDOM(section);
    }

    function completedStatusChange(isChecked, itemDOM) {
        var innerDiv;
        var contentSearched;

        innerDiv = itemDOM.getElementsByClassName('inner-div')[0];
        contentSearched = innerDiv.innerText;
        var itemSearched = searchItem(contentSearched);
        itemSearched.isCompleted = isChecked;

        colorChange(itemSearched.isCompleted, innerDiv);
    }

    function searchItem(contentSearched) {
        for (var sectionInContainer in container.sections) {
            for (var itemNumber in container.sections[sectionInContainer].items) {
                if (container.sections[sectionInContainer].items[itemNumber].content === contentSearched) {
                    return container.sections[sectionInContainer].items[itemNumber];
                }
            }
        }
    }

    function colorChange(isCompleted, innerDiv) {
        if(isCompleted) {
            innerDiv.style.background = 'lightgreen';
        } else {
            innerDiv.style.background = 'white';
        }
    }

    var container = Object.create(ContainerPrototype);
    container.constructor();

    container.addToDOM();

    return {
        ItemPrototype: ItemPrototype,
        SectionPrototype: SectionPrototype,
        ContainerPrototype: ContainerPrototype,
        createNewSection: createNewSection,
        addNewItem: addNewItem,
        completedStatusChange: completedStatusChange
    }
}());







//var airfresher = Object.create(toDoList.ItemPrototype);
//airfresher.constructor("airfresher");
//
//var pampers = Object.create(toDoList.ItemPrototype);
//pampers.constructor("pampers");
//
//var tasks = [airfresher, pampers, "pesho"];
//
//var section = Object.create(toDoList.SectionPrototype);
//section.constructor("shopping", tasks);
//
//var section2 = Object.create(toDoList.SectionPrototype);
//section2.constructor("other", "pesho");
//
//var container = Object.create(toDoList.ContainerPrototype);
//container.constructor([section, section2]);
//console.log(section);