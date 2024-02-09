import { AppState } from "../AppState";
import { Recipe } from "../models/Recipe";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class RecipeService {
	async getRecipes() {
		const res = await api.get("api/recipes");
		AppState.recipes = res.data.map((recipe) => new Recipe(recipe));
		logger.log(AppState.recipes);
	}
}

export const recipeService = new RecipeService();
