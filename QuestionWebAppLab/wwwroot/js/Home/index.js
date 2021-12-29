var vm = new Vue({
	el: "#app",
	data: {
		items: [
			"ABC 1",
			"ABC 2",
			"ABC 3",
			"ABC 4",
			"ABC 5",
		]
	},
	mounted: function () {

		var vm = this;

		var url = apiUrl.questionCategorie;

		axios
			.get(url)
			.then(response => (vm.items = response));

	},
	methods: {

	}
})

