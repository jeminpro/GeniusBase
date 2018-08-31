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
        	articleEditor.setData('some text');
        })
        .catch(err => {
        	console.error(err.stack);
        });

		$saveAsDraft.click(function () { saveArticle(true); });
		$publish.click(function () { saveArticle(false); });
		$moveToTrash.click(function () { moveToTrash(); });
	}

	let saveArticle = function (isDraft) {

		let articleData = {
			title: $articleTitle.val(),
			content: articleEditor.getData(),
			urlIdentifier: $articleTitle.val(),
			isDraft: isDraft,
			categoryId: 1
		}

		let url = "/api/post/savearticle";

		$.ajax({
			type: 'POST',
			url: url,
			contentType: 'application/json; charset=utf-8',
			dataType: 'json',
			data: JSON.stringify(articleData)
		})
		.done(function () {
			alert("second success");
		})
		.fail(function () {
			alert("error");
		});
	}

	let moveToTrash = function () {
		alert('Not yet implemented');
	}


	return {
		init: init,
		saveArticle: saveArticle
	}
})();