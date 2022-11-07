locals {
  name            = basename(path.cwd)
  region          = data.aws_region.current.name
  cluster_version = "1.23"

  vpc_cidr = "10.0.0.0/16"
  azs      = slice(data.aws_availability_zones.available.names, 0, 3)

  node_group_name = "managed-ondemand"

  #---------------------------------------------------------------
  # ARGOCD ADD-ON APPLICATION
  #---------------------------------------------------------------

  addon_application = {
    path               = "chart"
    repo_url           = "https://github.com/sjeversaws/eks-blueprints-add-ons"
    add_on_application = true
  }

  workload_application = {
    name                = "systems"
    path                = "helm"
    repo_url            = "git@ssh.gitlab.aws.dev:sjevers/system.git"
    project             = "default"
    add_on_application  = false         # Indicates the root add-on application.
    ssh_key_secret_name = "gitlab/ssh"  # Needed for private repos
    insecure            = false         # Set to true to disable the server's certificate verification
  }

  tags = {
    Blueprint  = local.name
    GithubRepo = "github.com/aws-ia/terraform-aws-eks-blueprints"
  }
}