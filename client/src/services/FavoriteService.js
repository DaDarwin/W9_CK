import { AppState } from "../AppState";
import { Recipe } from "../models/Recipe";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class FavoriteService {
	async FavoriteRecipe(id) {
		logger.log(id);
		const data = { recipeId: id };
		const res = await api.post("api/favorites", data);
		const index = AppState.recipes.findIndex((recipe) => recipe.id == id);
		AppState.recipes[index] = new Recipe(res.data);
	}

	async unFavorite(id) {
		await api.delete(`api/favorites/${id}`);
		const index = AppState.recipes.findIndex((recipe) => recipe.id == id);
		AppState.recipes[index].favorited = false;
		AppState.recipes[index].favoriteId = null;
	}
}

export const favoriteService = new FavoriteService();
