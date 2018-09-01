let CreateArticle = (function () {
	let articleId;
	let articleEditor;

	let $articleTitle = $('#articleTitle');
	let $saveAsDraft = $('#saveAsDraft');
	let $publish = $('#publish');
	let $moveToTrash = $('#moveToTrash');

    let init = function () {
        ClassicEditor
            .create(document.querySelector('#articleEditor'))
            .then(editor => {
                articleEditor = editor;
                //articleEditor.setData('some text');
            })
            .catch(err => {
                console.error(err.stack);
            });

        $saveAsDraft.click(function () { saveArticle(true); });
        $publish.click(function () { saveArticle(false); });
        $moveToTrash.click(function () { moveToTrash(); });
    };

    let saveArticle = function (isDraft) {

        let articleData = {
            title: $articleTitle.val(),
            content: articleEditor.getData(),
            urlIdentifier: $articleTitle.val(),
            isDraft: isDraft,
            categoryId: 1
        };


        if (articleId) {
            updateArticle(articleId, articleData);
        } else {
            addArticle(articleData);
        }
    };

    let addArticle = function (articleData) {

        let url = "/api/post/addArticle";

        $.ajax({
            type: 'POST',
            url: url,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            data: JSON.stringify(articleData)            
        })
            .done(function (data) {
                let message = articleData.isDraft ? `Saved as draft` : `Successfully published`;
                toastr["success"](message);
                articleId = data;
            })
            .fail(function () {
                toastr["error"]("Something went wrong while saving");
            });    
    };


    let updateArticle = function (articleId, articleData) {

        let url = `/api/post/updateArticle/${articleId}`;

        $.ajax({
            type: 'POST',
            url: url,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(articleData)
        })
            .done(function () {
                let message = articleData.isDraft ? `Draft updated` : `Successfully published`;
                toastr["success"](message);
            })
            .fail(function () {
                toastr["error"]("Something went wrong while updating");
            });
    };

    let moveToTrash = function () {
        alert('Not yet implemented');
    };

    return {
        init: init,
        saveArticle: saveArticle
    };
})();