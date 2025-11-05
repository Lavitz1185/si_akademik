$(function () {
    $('.import-file-input').each(function () {
        const fileInput = this;
        const label = $(fileInput).siblings('label[for="' + $(fileInput).attr('id') + '"]').get(0);

        window.addEventListener("drop", (e) => {
            if ([...e.dataTransfer.items].some((item) => item.kind === "file")) {
                e.preventDefault();
            }
        });

        label.addEventListener("dragover", (e) => {
            const fileItems = [...e.dataTransfer.items].filter(
                (item) => item.kind === "file",
            );

            if (fileItems.length > 0) {
                e.preventDefault();
                e.dataTransfer.dropEffect = "copy";
            }
        });

        window.addEventListener("dragover", (e) => {
            const fileItems = [...e.dataTransfer.items].filter(
                (item) => item.kind === "file",
            );
            if (fileItems.length > 0) {
                e.preventDefault();
                if (!label.contains(e.target)) {
                    e.dataTransfer.dropEffect = "none";
                }
            }
        });

        label.addEventListener("drop", function (e) {
            const fileItems = [...e.dataTransfer.items].filter(
                (item) => item.kind === "file",
            );
            if (fileItems.length > 0) {
                e.preventDefault();

                const fileItem = fileItems[0].getAsFile();
                const dataTransfer = new DataTransfer();
                dataTransfer.items.add(fileItem);
                fileInput.files = dataTransfer.files;

                $(label).children('.file-name').text(fileItem.name)
            }
        });

        $(fileInput).on('change', function () {
            $(label).children('.file-name').text(fileInput.files[0].name)
        })
    })
});