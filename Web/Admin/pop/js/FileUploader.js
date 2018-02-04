window.FileUploader = (function () {
	String.prototype.endsWith = function (ends) {
		var result = this.slice(this.length - ends.length);
		return result == ends;
	}
	Number.prototype.toFileSize = function () {
		if (this < 1024) {
			return this + 'byte';
		}

		if (this < 1024 * 1024) {
			return (this / 1024).saveDecimal() + 'KB';
		}

		if (this < 1024 * 1024 * 1024) {
			return (this / (1024 * 1024)).saveDecimal() + 'MB';
		}

		return (this / (1024 * 1024 * 1024)).saveDecimal() + 'GB'
	}

	Number.prototype.saveDecimal = function () {
		var str = this.toString();
		var dotIndex = str.lastIndexOf('.');
		if (dotIndex == -1) {
			return str + ".00";
		} else {
			return str.substring(0, dotIndex + 3);
		}
	}

	function SelectedFile(file) {

		var state = 0;  //0表示没有上传

		var defaultConfig = {
			url: '',
			onBeforeUpload: function (file) {

			},
			data: {},
			onFailed: function (file) {
				alert('上传文件失败');
			},
			onSuccess: function (responseText, file) {
				alert('上传成功');
			},
			onProgress: function (progress) {
				console.log(progress);
			}
		};


		function checkConfig(config) {
			if (!config.url) {
				return false;
			}
			return true;
		}

		this.Upload = function (config) {
			if (state != 0) {
				return;
			}
			state = 1;
			var newConfig = $.extend({}, defaultConfig, config);
			var result = newConfig.onBeforeUpload(file);
			if (result !== false) {
				var checkResult = checkConfig(newConfig);
				if (checkResult == false) {
					throw '由于参数错误，所以无法上传文件';
				}

				var formData = new FormData();
				formData.append('file', file);

				for (var item in newConfig.data) {
					formData.append(item, newConfig.data[item]);
				}
				var xhr = new XMLHttpRequest();

				//xhr.addEventListener('abort', function () {
				//	//newConfig.onFailed(file);
				//});
				xhr.addEventListener('error', function () {
					newConfig.onFailed(file);
				});
				xhr.addEventListener('timeout', function () {
					newConfig.onFailed(file);
				});
				xhr.onreadystatechange = function () {
					if (xhr.readyState == 4) {
						if (xhr.status != 200) {
							newConfig.onFailed(file);
						} else {
							newConfig.onSuccess(xhr.responseText, file);
						}
					}
				}

				var now = new Date();

				xhr.onloadstart = function () {
					now = new Date();
				}

				var lastLoaded = 0;


				xhr.onprogress = function (eventData) {
					if (eventData.lengthComputable == false) {
						return;
					}
					console.log(eventData);
					var last = now;
					now = new Date();

					var timespan = now.getMilliseconds() - last.getMilliseconds();

					var difference = eventData.loaded - lastLoaded;
					lastLoaded = eventData.loaded;

					var speed = difference / (timespan / 1000);  //速度

					var progressData = {
						total: eventData.total,
						loaded: eventData.loaded,
						percent: (eventData.loaded / eventData.total),
						percentStr: (eventData.loaded / eventData.total * 100).saveDecimal() + '%',
						loadedSize: (eventData.loaded / eventData.total * file.size).toFileSize(),
						totalSize: file.size.toFileSize()
					};
					progressData.fileProgress = progressData.loadedSize + '/' + progressData.totalSize;
					newConfig.onProgress(progressData);
				}
				xhr.onloadend = function () {
					console.log('onloadend');
				}

				xhr.open('post', newConfig.url);
				xhr.send(formData);
			}
		}
	}

	function internalObject() {

		var self = this;
		self.lastInputID = undefined;

		function initGetFiles() {
			if (self.lastInputID != undefined) {
				var ele = document.getElementById(self.lastInputID);
				if (ele) {
					ele.remove();
				}
			}
		}
		function randstr(len) {
			var num = Math.random().toString();
			return num.substring(num.length - len);
		}

		this.GetFile = function (callback) {
			initGetFiles();

			self.lastInputID = 'FileSelector_' + randstr(4);

			var fileInput = document.createElement('input');
			fileInput.type = 'file';
			fileInput.id = self.lastInputID;
			fileInput.style.display = 'none';

			fileInput.onchange = function () {
				if (this.value && this.files.length != 0) {

					if (callback) {
						var f = new SelectedFile(this.files[0]);
						callback.call(f, f);
					}
				}
			}
			document.body.appendChild(fileInput);
			fileInput.click();
		}
	}
	return new internalObject();
})();