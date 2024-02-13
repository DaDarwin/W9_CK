export class Ingredient {
	constructor(data) {
		this.id = data.id;
		this.dateCreated = data.dateCreated;
		this.dateUpdated = data.dateUpdated;
		this.name = data.name;
		this.quantity = data.quantity;
	}
}
