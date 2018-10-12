var blazorSplit = {
    splitRef: {},

    init: function (interopHelper, id, elements, options, initOptions) {
        if (initOptions.onDrag) {
            options.onDrag = function() {
                interopHelper.invokeMethodAsync("OnDrag");
            };
        }

        if (initOptions.onDragStart) {
            options.onDragStart = function(sizes) {
                interopHelper.invokeMethodAsync("OnDragStart", sizes);
            };
        }

        if (initOptions.onDragEnd) {
            options.onDragEnd = function(sizes) {
                interopHelper.invokeMethodAsync("OnDragEnd", sizes);
            };
        }

        try {
            blazorSplit.splitRef[id] = window.Split(elements, options);
        } catch (e) {
            debugger;
        }
    }
};