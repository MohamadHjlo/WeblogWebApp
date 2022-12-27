/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	 //Define changes to default configuration here. For example:
	config.apiKey = "1H8PDFLT";
	config.contentsLangDirection = 'rtl';
	config.language = 'fa';
	config.uiColor = '#f9f8f6';
	config.extraPlugins = "wordcount, html5video,widget,clipboard,widgetselection,lineutils,preview";
	//config.extraPlugins = "N1ED-editor";
	//config.skin = "n1theme"; // own CKEditor theme, included into ZIP
	config.removePlugins = "iframe"; // N1ED needs IFrame plugin to be removed, it has own support of iframes
	config.filebrowserImageUploadUrl = '/ckEditor-file-upload';
	config.filebrowserUploadUrl = '/ckEditor-file-upload';
	config.filebrowserBrowseUrl = '/ckEditor-file-upload';
	config.wordcount = {

		// Whether or not you want to show the Word Count
		showWordCount: true,

		// Whether or not you want to show the Char Count
		showCharCount: false,

		// Maximum allowed Word Count
		maxWordCount: -1,

		// Maximum allowed Char Count
		maxCharCount: -1
	};
	//config.extraPlugins = "N1ED-editor, file-manager";
	//config.toolbar = [['Upload', 'Flmngr', 'ImgPen']];
	//config.Flmngr = {
		//urlFileManager: 'https://localhost:44339/fileManager',
		//urlFiles: 'https://localhost:44339/files'
		//https://fm.flmngr.com/fileManager
		//https://fm.flmngr.com/files/
	//}
};
