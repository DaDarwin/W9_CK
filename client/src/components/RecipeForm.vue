<template>
	<section class="row justify-content-center">
		<div class="col-12 col-md-6 box-shadow rounded p-2">
			<div class="fs-3 text-center border-secondary">Share a Recipe!</div>
			<form
				@submit="createRecipe()"
				class="row justify-content-between m-1">
				<div class="col-12">
					<label for="recipe-title">Title</label>
					<input
						v-model="data.title"
						id="recipe-title"
						type="text"
						class="form-control" />
				</div>
				<div class="col-6">
					<label for="recipe-catagory">Catagory</label>
					<select
						id="recipe-catagory"
						v-model.catagory="data.catagory"
						class="form-control">
						<option disabled></option>
						<option
							v-for="option in options"
							:value="option"></option>
					</select>
				</div>
				<div class="col-6">
					<label for="recipe-img">Img</label>
					<input
						id="recipe-img"
						v-model="data.img"
						type="text"
						class="form-control" />
				</div>
				<div class="col-10">
					<label for="recipe-insructions">Insructions</label>
					<textarea
						v-model="data.instructions"
						id="recipe-insructions"
						cols="30"
						class="form-control"
						rows="5"></textarea>
				</div>
				<div class="col-2 d-flex justify-content-end align-items-end p-1">
					<button class="btn btn-info text-light fs-4">
						Post <i class="mdi mdi-mail"></i>
					</button>
				</div>
			</form>
		</div>
	</section>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
export default {
	setup() {
		const data = ref({});
		return {
			options: computed(() => AppState.options),
			data,
		};
	},
};
</script>

<style lang="scss" scoped>
.box-shadow {
	box-shadow: 0 0 1em black;
}
</style>
