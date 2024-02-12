<template>
	<div class="p-4">
		<section
			:style="`background-image: url(${recipe.img});`"
			class="m-3 rounded p-2 d-flex flex-column justify-content-between">
			<div class="d-flex justify-content-between">
				<span
					class="bg-dark bg-opacity-50 text-light m-2 rounded p-1 fs-4 selectable"
					>{{ recipe.category }}</span
				>
				<i
					@click="favorite(recipeId, recipe.favoriteId)"
					class="mdi bg-dark bg-opacity-50 m-2 rounded px-2 py-1 fs-3 text-danger selectable"
					:class="{
						'mdi-heart': recipe.favorited,
						'mdi-heart-outline': !recipe.favorited,
					}"></i>
			</div>

			<div class="bg-dark bg-opacity-50 text-light m-2 rounded p-1 selectable">
				<div class="fs-4">{{ recipe.title }}</div>
				<div>{{ recipe.subtitle }}</div>
			</div>
		</section>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
import { Recipe } from "../models/Recipe";
import Pop from "../utils/Pop";
import { favoriteService } from "../services/FavoriteService.js";
export default {
	props: { recipe: { type: Recipe, required: true } },
	setup(props) {
		async function favorite() {
			try {
				if (props.recipe.favorited) {
					await favoriteService.unFavorite(props.recipe.id);
					Pop.success("Recipe Unfavorited");
				} else {
					await favoriteService.FavoriteRecipe(props.recipe.id);
					Pop.success("Recipe Favorited");
				}
			} catch (error) {
				Pop.error(error);
			}
		}
		return {
			favorite,
		};
	},
};
</script>

<style lang="scss" scoped>
section {
	height: 45vh;
	background-position: center;
	background-size: cover;
	box-shadow: 0 0 1em black;
}
</style>
