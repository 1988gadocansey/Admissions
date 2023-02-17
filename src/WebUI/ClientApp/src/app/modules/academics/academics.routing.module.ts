import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcademicsComponent } from './academics.component';
import { CourseRegistrationComponent } from './pages/course-registration/course-registration.component';
import { AuthorizeGuard } from '../../../api-authorization/authorize.guard';
const routes: Routes = [
    {
        path: '',
        component: AcademicsComponent,
        children: [

            { path: '', redirectTo: 'registration', pathMatch: 'full' },
            { path: 'registration', component: CourseRegistrationComponent, canActivate: [AuthorizeGuard] },

            { path: '**', redirectTo: '/404' },

        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AcademicsRoutingModule { }
