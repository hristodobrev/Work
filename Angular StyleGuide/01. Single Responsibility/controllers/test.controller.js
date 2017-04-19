(function () {
	angular
	.module('app')
	.controller('Test', test);

	function test() {
		let vm = this;

		vm.title = 'This is some test title';
		vm.content = 'This is some sample content of the test view';
	}
})();