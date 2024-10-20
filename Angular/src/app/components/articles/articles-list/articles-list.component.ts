import { Component } from '@angular/core';
import { Article } from '../../../types/articles';
import { ArticlesService } from '../articles.service';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrl: './articles-list.component.css'
})
export class ArticlesListComponent {

  articles: Article[] = [];

  constructor(private articlesService: ArticlesService) {

  }

  ngOnInit() {
    this.articlesService.getArticles().subscribe((response) => {
      this.articles = response.result
      console.log(this.articles)
    })
  }
}
