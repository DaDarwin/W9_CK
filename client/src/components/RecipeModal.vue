<template>
	<div
		v-if="recipe"
		class="modal modal-xl fade box-shadow"
		id="recipeModal"
		tabindex="-1"
		aria-labelledby="recipeModalLabel"
		aria-hidden="true">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-body row p-4">
					<div class="col-6 rounded p-0 box-shadow">
						<img
							class="rounded"
							:src="recipe.img"
							:alt="`${recipe.title} Img`" />
					</div>
					<div class="col-6">
						<div class="d-flex justify-content-between rounded box-shadow p-2">
							<div class="fs-3">
								{{ recipe.title }}
							</div>
							<button
								type="button"
								class="btn-close p-3"
								data-bs-dismiss="modal"
								aria-label="Close"></button>
						</div>
						<div class="w-100 mt-4 p-2 box-shadow rounded">
							<span class="fs-5">Instructions</span>
							<p>
								{{ recipe.instructions }}
							</p>
							<br />
							<div class="fs-5">Ingredients</div>
							<i v-for="ingredient in ingredients">
								<i class="mdi mdi-circle-medium"></i>
								{{ ingredient.name }}
								{{ ingredient.quantity }}
							</i>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
import { AppState } from "../AppState";
import { computed, ref, onMounted } from "vue";
export default {
	setup() {
		return {
			recipe: computed(() => AppState.activeRecipe),
			ingredients: computed(() => AppState.activeRecipeIngredients),
		};
	},
};
</script>

<style lang="scss" scoped>
img {
	object-fit: cover;
	object-position: center;
	width: 100%;
}

.box-shadow {
	box-shadow: 0 0 1em black;
}
</style>
