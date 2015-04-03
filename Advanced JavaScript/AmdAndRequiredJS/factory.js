define('factory', [], function() {
    this.container;

    function createNewContainer() {
        require(['container'], function(Container) {
            this.container = new Container();
            this.container.addToDOM();

            return this.container;
        });
    }

    function createNewSection(containerDOM, sectionContainer) {
        require(['section'], function(Section) {
            var textBox;
            var input;
            console.log(containerDOM);
            textBox = containerDOM.getElementsByClassName('section-adder')[0];
            input = textBox.value;

            console.log(this);
            if (!input) {
                return;
            }
            var sectionToAdd = new Section(input);
            sectionContainer.sections.push(sectionToAdd);
            sectionToAdd.addToDOM(containerDOM);
            textBox.value = "";

        })
    }

    function createNewItem(sectionDOM, itemContainer) {
        require(['item'], function(Item) {
            var textBox = sectionDOM.getElementsByClassName('item-description')[0];
            var input = textBox.value;

            if(!input) {
                return;
            }
            var itemToAdd = new Item(input);
            itemContainer.items.push(itemToAdd);
            itemToAdd.addToDOM(sectionDOM);
            textBox.value = '';
        })
    }

    return {
        createNewContainer: createNewContainer,
        createNewSection: createNewSection,
        createNewItem: createNewItem
    }
});

