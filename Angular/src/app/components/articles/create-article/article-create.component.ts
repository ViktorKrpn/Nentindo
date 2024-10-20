import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ArticlesService } from '../articles.service';



@Component({
  selector: 'app-article-craete',
  templateUrl: './article-create.component.html',
  styleUrl: './article-create.component.css'
})

export class ArticleCreateComponent {

  createArticleForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private articlesService: ArticlesService,
    private toastr: ToastrService,
    private router: Router) { }


  ngOnInit(): void {
    this.initCreateArticleForm();
  }

  initCreateArticleForm() {
    this.createArticleForm = this.fb.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      summary: ['', [Validators.required]],
    });
  }

  submitArticleForm() {
    if (this.createArticleForm.invalid) {
      this.toastr.error('Please fill in all fields');
      return;
    }

    this.articlesService.createArticle(this.createArticleForm.value)
      .subscribe({
        next: (response) => {
          if (response.isSuccessful) {
            this.toastr.success('Article created successfully');
            this.router.navigate(['/articles']);
          } else {
            this.toastr.error('Failed to create article');
          }
        },
        error: (error) => {
          this.toastr.error(JSON.stringify(error));
        }
      });
  }


}
