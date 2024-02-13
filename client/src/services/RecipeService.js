import { AppState } from "../AppState";
import { Ingredient } from "../models/Ingredient";
import { Recipe } from "../models/Recipe";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class RecipeService {
	async getRecipes() {
		const res = await api.get("api/recipes");
		const recipes = res.data.map((recipe) => new Recipe(recipe));
		AppState.recipes = recipes;
	}
	async getAccountFavorites() {
		const res = await api.get("Account/favorites");
		const favoriteRecipes = res.data.map((pojo) => new Recipe(pojo));

		for (let i = 0; i < favoriteRecipes.length; i++) {
			let index = AppState.recipes.findIndex(
				(recipe) => recipe.id == favoriteRecipes[i].id
			);
			AppState.recipes[index] = favoriteRecipes[i];
		}
	}

	async selectRecipe(recipe) {
		AppState.activeRecipe = recipe;
		const res = api.get(`api/recipes/${recipe.id}/ingredients`);
		AppState.activeRecipeIngredients = (await res).data.map(
			(pojo) => new Ingredient(pojo)
		);
		console.log(AppState.activeRecipeIngredients);
	}

	// async getProfileRecipes(id) {
	// 	TODO add profiles const res = await api.get(`profiles/${id}/recipes`);
	// 	AppState.profileRecipes = res.data.map((pojo) => new Recipe(pojo));
	// }

	// async getProfileFavorites(id) {
	// 	const res = await api.get(`api/profiles/${id}/favorites`);
	// 	AppState.profileFavoritess = res.data.map((pojo) => new Recipe(pojo));
	// }
}

export const recipeService = new RecipeService();
