<template>
	<section class="d-flex flex-column align-items-center w-100 p-3 mb-5">
		<div class="position-relative w-100 box-shadow rounded">
			<NavBar class="position-absolute top-0 end-0 nav" />

			<div
				class="text-light text-center position-absolute top-50 start-50 translate-middle">
				<div class="fs-3">All-Spice</div>
				<div class="fs-5">Words Go here</div>
			</div>

			<span
				class="position-absolute top-100 start-50 translate-middle w-fit bg-primary box-shadow rounded d-flex">
				<button
					@click="selecton = 'home'"
					class="btn selectable fs-4"
					:class="{
						'bg-info': selecton == 'home',
						'text-primary': selecton == 'home',
						'text-info': selecton != 'home',
						'rounded-end-0': account.id,
					}">
					Home
				</button>
				<button
					v-if="account.id"
					@click="selecton = 'myRecipes'"
					class="btn selectable rounded-0 fs-4 w-fit"
					:class="{
						'bg-info': selecton == 'myRecipes',
						'text-primary': selecton == 'myRecipes',
						'text-info': selecton != 'myRecipes',
					}">
					My Recipes
				</button>
				<button
					v-if="account.id"
					@click="selecton = 'favorite'"
					class="btn selectable rounded-start-0 fs-4"
					:class="{
						'bg-info': selecton == 'favorite',
						'text-primary': selecton == 'favorite',
						'text-info': selecton != 'favorite',
					}">
					Favorites
				</button>
			</span>

			<img
				class="rounded"
				src="https://media.istockphoto.com/id/1218254547/photo/varied-food-carbohydrates-protein-vegetables-fruits-dairy-legumes-on-wood.webp?b=1&s=170667a&w=0&k=20&c=uGHRWrmqv4Nxdj7iUO4iYavWLjqFB3uwH1K3RQ9NID0=" />
		</div>
		<div class="mt-5 w-100">
			<RecipeForm />
			<div
				class="row justify-content-evenly w-100"
				v-if="recipes.length">
				<RecipeCard
					v-for="recipe in recipes"
					:key="recipe.id"
					:recipe="recipe"
					class="col-12 col-md-4" />
			</div>
		</div>
		<RecipeModal />
	</section>
</template>

<script>
import { onMounted, ref, computed } from "vue";
import Pop from "../utils/Pop";
import NavBar from "../components/Navbar.vue";
import RecipeCard from "../components/RecipeCard.vue";
import RecipeModal from "../components/RecipeModal.vue";
import RecipeForm from "../components/RecipeForm.vue";
import { AppState } from "../AppState";
import { recipeService } from "../services/RecipeService";

export default {
	setup() {
		onMounted(() => {
			getRecipes();
		});
		let selecton = ref("home");

		async function getRecipes() {
			try {
				await recipeService.getRecipes();
			} catch (error) {
				Pop.error(error);
			}
		}

		return {
			selecton,
			recipes: computed(() => {
				if (selecton.value == "myRecipes")
					return AppState.recipes.filter(
						(recipe) => (recipe.creatorId = AppState.account.id)
					);
				else if (selecton.value == "favorite")
					return AppState.recipes.filter((recipe) => recipe.favorited);
				else return AppState.recipes;
			}),
			account: computed(() => AppState.account),
		};
	},
	components: { NavBar, RecipeCard, RecipeModal, RecipeForm },
};
</script>

<style scoped lang="scss">
img {
	background-image: url("https://images.unsplash.com/photo-1606914501449-5a96b6ce24ca?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8Zm9vZCUyMGJhY2tncm91bmR8ZW58MHx8MHx8fDA%3D");
	width: 100%;
	height: 30vh;
	object-fit: cover;
	object-position: center;
}

.nav {
	transform: translate(-5%, 5%);
}

.box-shadow {
	box-shadow: 0 0 1em black;
}
</style>
