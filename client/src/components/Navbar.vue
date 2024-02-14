<template>
	<span class="align-self-end w-fit d-flex align-items-baseline">
		<form
			class="searchbar w-fit d-flex box-shadow"
			action="">
			<input
				type="text"
				class="form-control rounded-0"
				placeholder="Search" />
			<button class="btn btn-outline-light rounded-0 border-start-0">
				<i class="mdi mdi-magnify"></i>
			</button>
		</form>
		<button
			class="btn text-light rounded-circle mx-2"
			@click="toggleTheme">
			<i
				class="mdi"
				:class="
					theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'
				"></i>
		</button>
		<Login />
	</span>
</template>

<script>
import { onMounted, ref } from "vue";
import { loadState, saveState } from "../utils/Store.js";
import Login from "./Login.vue";
export default {
	setup() {
		const theme = ref(loadState("theme") || "light");

		onMounted(() => {
			document.documentElement.setAttribute("data-bs-theme", theme.value);
		});

		return {
			theme,
			toggleTheme() {
				theme.value = theme.value == "light" ? "dark" : "light";
				document.documentElement.setAttribute("data-bs-theme", theme.value);
				saveState("theme", theme.value);
			},
		};
	},
	components: { Login },
};
</script>

<style scoped>
a:hover {
	text-decoration: none;
}

.nav-link {
	text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
	border-bottom: 2px solid var(--bs-success);
	border-bottom-left-radius: 0;
	border-bottom-right-radius: 0;
}

button:hover {
	background-color: white;
	box-shadow: 0 0 1em black;

	i {
		color: black;
	}
}

.box-shadow {
	box-shadow: 0 0 1em black;
}

@media screen and (min-width: 576px) {
	nav {
		height: 64px;
	}
}
</style>
