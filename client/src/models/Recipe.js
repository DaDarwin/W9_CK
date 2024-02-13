export class Recipe {
	constructor(data) {
		this.id = data.id;
		this.dateCreated = data.dateCreated;
		this.dateUpdated = data.dateUpdated;

		this.title = data.title;
		this.category = data.category;
		this.img = data.img;
		this.instructions = data.instructions;

		this.creatorId = data.creatorId;
		this.creator = data.creator;

		this.favoriteId = data.favoriteId || null;
		this.favorited = Boolean(data.favoriteId);
	}
}
