<template>
	<div class="row justify-content-evenly">
		<RecipeCard
			v-for="recipe in recipes"
			:key="recipe.id"
			:recipe="recipe"
			class="col-12 col-md-4" />
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import Pop from "../utils/Pop";
import { recipeService } from "../services/RecipeService.js";

export default {
	setup() {
		onMounted(() => {
			getRecipes();
		});

		async function getRecipes() {
			try {
				await recipeService.getRecipes();
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			recipes: computed(() => AppState.recipes),
		};
	},
};
</script>

<style lang="scss" scoped></style>
