var blazorSplit = {
    splitRef: {},
    splitAreaRef: {},
    interopHelpers: {},

    init: function(data, interopHelper) {
        var options = data.options;

        blazorSplit.interopHelpers[data.id] = interopHelper;
        options.onDrag = function() {
            interopHelper.invokeMethodAsync("OnDrag");
        };

        options.onDragStart = function(sizes) {
            interopHelper.invokeMethodAsync("OnDragStart", sizes);
        };

        options.onDragEnd = function(sizes) {
            interopHelper.invokeMethodAsync("OnDragEnd", sizes);
        };


        var splitEl = document.getElementById(data.id);
        var elements = [];
        var ids = [];
        
        for (var i = 0; i < splitEl.children.length; i++) {
            var areaEl = splitEl.children[i];
            elements.push("#" + areaEl.id);
            ids.push(areaEl.id);
            blazorSplit.splitAreaRef[areaEl.id] = splitEl.id;
        }
        try {
            blazorSplit.splitRef[data.id] = window.Split(elements, options);
        } catch (e) {

            debugger;
        }

        return {
            elements: elements
        };

    }
};